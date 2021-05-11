import {compose, Dispatch} from 'redux';
import {updateUser as updateStoreUser} from '../../store/user/user-action-creators';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import InvitePageView from './invite-page-view';
import {IRoom, IRootState, IPlayer} from '../../store/types';
import {roomSelector} from '../../store/room/room-selectors';
import {addUser} from '../../store/room/room-action-creators';
import * as roomApi from '../../api/room-api';
import * as playerApi from '../../api/player-api';

const mapStateToProps = (state: IRootState) => {
  const room = roomSelector(state);
  return {
    room,
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    addUserIntoRoom: async (room: IRoom, newUser: IPlayer) => {
      await roomApi.addPlayerIntoRoomRequest(room.id, newUser.id);
      dispatch(addUser(room, newUser));
    },
    updateUser: async (name: string | null) => {
      const user = name ? await playerApi.createPlayerRequest(name) : null;
      dispatch(updateStoreUser(user));
      return user;
    },
  };
};

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(InvitePageView);
