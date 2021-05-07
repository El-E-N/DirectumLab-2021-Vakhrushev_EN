import {compose, Dispatch} from 'redux';
import {updateUser as updateNewUser} from '../../store/user/user-action-creators';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import InvitePageView from './invite-page-view';
import {IRoom, IRootState, IUser} from '../../store/types';
import {roomSelector} from '../../store/room/room-selectors';
import {addUser} from '../../store/room/room-action-creators';
import * as api from '../../api/api';

const mapStateToProps = (state: IRootState) => {
  const room = roomSelector(state);
  return {
    room,
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    addUserIntoRoom: async (room: IRoom, newUser: IUser) => {
      await api.addUserIntoRoom(room.id, newUser.id);
      dispatch(addUser(room, newUser));
    },
    updateUser: async (name: string | null) => {
      const user = name ? await api.createUserRequest(name) : null;
      dispatch(updateNewUser(user));
      return user;
    },
  };
};

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(InvitePageView);
