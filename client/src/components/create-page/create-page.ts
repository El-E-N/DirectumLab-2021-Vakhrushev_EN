import {compose, Dispatch} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import CreatePageView from './create-page-view';
import {createRoom as createNewRoom} from '../../store/room/room-action-creators';
import {updateUser as updateNewUser} from '../../store/user/user-action-creators';
import * as api from '../../api/api';
import {IRoom} from '../../store/types';

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    createRoom: async (roomName: string, creatorId: string) => {
      const roomApi = await api.createRoomRequest(roomName, creatorId);
      const room: IRoom = {
        id: roomApi.id,
        hash: roomApi.hash,
        name: roomApi.name,
        users: roomApi.players,
        hostId: roomApi.hostId,
        creatorId: roomApi.creatorId,
        cards: ['0', '0.5', '1', '2', '3', '5', '8', '13', '20', '40', '100', '?', '∞', 'coffee'],
        selectedCard: null
      };
      dispatch(createNewRoom(room));
      return room;
    },
    updateUser: async (name: string | null) => {
      const user = name ? await api.createUserRequest(name) : null;
      dispatch(updateNewUser(user));
      return user;
    },
  };
};

export default compose<React.ComponentClass>(withRouter, connect(null, mapDispatchToProps))(CreatePageView);
