import {compose} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import InvitePageView from './invite-page-view';
import {IRootState} from '../../store/types';
import {roomSelector} from '../../store/room/room-selectors';
import {updateUser} from '../../store/user/user-operations';
import {Dispatch} from 'redux';
import {userSelector} from '../../store/user/user-selectors';

const mapStateToProps = (state: IRootState) => {
  const room = roomSelector(state);
  const player = userSelector(state);
  return {
    room,
    player
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    updateUser: async (name: string | null) => {
      return dispatch(await updateUser(name));
    }
  };
};

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(InvitePageView);
