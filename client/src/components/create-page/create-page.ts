import {compose, Dispatch} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import CreatePageView from './create-page-view';
import {createRoom as createNewRoom} from '../../store/room/room-action-creators';
import {updateUser as updateNewUser} from '../../store/user/user-action-creators';
import {IRoom, IUser} from '../../store/types';

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    createRoom: (room: IRoom) =>
      dispatch(createNewRoom(room)),
    updateUser: (user: IUser | null) => dispatch(updateNewUser(user)),
  };
};

export default compose<React.ComponentClass>(withRouter, connect(null, mapDispatchToProps))(CreatePageView);
