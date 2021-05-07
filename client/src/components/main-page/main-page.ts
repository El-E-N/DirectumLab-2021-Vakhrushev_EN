import {IRoom, IRootState} from '../../store/types';
import {compose, Dispatch} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import MainPageView from './main-page-view';
import {roomSelector} from '../../store/room/room-selectors';
import {userSelector} from '../../store/user/user-selectors';
import * as api from '../../api/api';
import {createRoom as createNewRoom} from '../../store/room/room-action-creators';
import {updateUser as updateNewUser} from '../../store/user/user-action-creators';

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
      const roomApi = await api.getRoomRequest(roomHash);
      const room: IRoom = {
        id: roomApi.id,
        hash: roomApi.roomHash,
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

export default compose<React.ComponentClass<IMain>>(withRouter, connect(mapStateToProps, mapDispatchToProps))(MainPageView);
