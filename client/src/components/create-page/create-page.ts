import {compose} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import CreatePageView from './create-page-view';
import {createRoom} from '../../store/room/room-operations';
import {updateUser} from '../../store/user/user-operations';
import {createDiscussion} from '../../store/discussion/discussion-operations';
import {Dispatch} from 'redux';

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    createRoom: async (roomName: string, creatorId: string) => {
      return dispatch(await createRoom(roomName, creatorId));
    },
    createUser: async (name: string | null) => {
      return dispatch(await updateUser(name));
    },
    createDiscussion: async (roomId: string) => {
      dispatch(await createDiscussion(roomId));
    },
  };
};

export default compose<React.ComponentClass>(withRouter, connect(null, mapDispatchToProps))(CreatePageView);
