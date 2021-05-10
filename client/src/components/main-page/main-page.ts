import {IRootState} from '../../store/types';
import {compose, Dispatch} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import MainPageView from './main-page-view';
import {roomSelector} from '../../store/room/room-selectors';
import {userSelector} from '../../store/user/user-selectors';
import {getRoom} from '../../store/room/room-operations';
import {updateUser} from '../../store/user/user-operations';

interface IMain {
  onShowModal(): void;
}

const mapStateToProps = (state: IRootState) => {
  const room = roomSelector(state);
  const user = userSelector(state);
  return {
    room,
    user
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    getRoom: async (roomHash: string) => {
      return dispatch(await getRoom(roomHash));
    },
    createUser: async (name: string | null) => {
      return dispatch(await updateUser(name));
    },
  };
};

export default compose<React.ComponentClass<IMain>>(withRouter, connect(mapStateToProps, mapDispatchToProps))(MainPageView);
