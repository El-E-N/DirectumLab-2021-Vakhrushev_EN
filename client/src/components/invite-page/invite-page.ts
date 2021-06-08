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
import {loadingPlayerByTokenRequest} from '../../api/player-api';
import authService from '../../services/auth-service';
import {updateUser as updateStoreUser} from '../../store/user/user-action-creators';
import {loadingRoom} from '../../store/room/room-operations';

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
      return dispatch(await updateUser(name)(dispatch));
    },

    getPlayerByToken: async () => {
      const response = await loadingPlayerByTokenRequest();
      authService.set(response.token);
      return dispatch(updateStoreUser({id: response.id, name: response.name}));
    },

    loadingRoom: async (roomHash: string, choosedDiscussionId: string | null) => {
      return dispatch(await loadingRoom(roomHash, choosedDiscussionId)(dispatch));
    },
  };
};

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(InvitePageView);
