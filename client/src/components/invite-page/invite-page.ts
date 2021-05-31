import {compose} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import InvitePageView from './invite-page-view';
import {IRoom, IRootState, IPlayer} from '../../store/types';
import {roomSelector} from '../../store/room/room-selectors';
import {addUser} from '../../store/room/room-action-creators';
import * as roomApi from '../../api/room-api';
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
    addUserIntoRoom: async (room: IRoom, newUser: IPlayer) => {
      await roomApi.addPlayerIntoRoomRequest(room.id, newUser.id);
      return addUser(newUser);
    },
    updateUser: async (name: string | null) => {
      return dispatch(await updateUser(name));
    }
  };
};

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(InvitePageView);
