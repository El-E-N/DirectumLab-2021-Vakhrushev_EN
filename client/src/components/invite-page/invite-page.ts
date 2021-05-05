import {compose, Dispatch} from 'redux';
import {updateUser as updateNewUser} from '../../store/user/user-action-creators';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import InvitePageView from './invite-page-view';
import {IRoom, IRootState, IUser} from '../../store/types';
import {roomSelector} from '../../store/room/room-selectors';
import {addUser} from '../../store/room/room-action-creators';

const mapStateToProps = (state: IRootState) => {
  const room = roomSelector(state);
  return {
    room,
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    updateUser: (user: IUser | null) => dispatch(updateNewUser(user)),
    addUserIntoRoom: (room: IRoom, newUser: IUser) => dispatch(addUser(room, newUser)),
  };
};

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(InvitePageView);
