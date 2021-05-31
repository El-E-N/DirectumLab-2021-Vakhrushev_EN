import {compose} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import CreatePageView from './create-page-view';
import {createRoom} from '../../store/room/room-operations';
import {updateUser} from '../../store/user/user-operations';
import * as discussionApi from '../../api/discussion-api';
import {createVote} from '../../store/discussions/discussions-operations';
import {Dispatch} from 'redux';
import {IRootState} from '../../store/types';
import {userSelector} from '../../store/user/user-selectors';
import {roomSelector} from '../../store/room/room-selectors';
import { discussionByIdSelector, discussionsSelector } from '../../store/discussions/discussions-selectors';

const mapStateToProps = (state: IRootState) => {
  const room = roomSelector(state);
  const discussions = discussionsSelector(state);
  const discussion = (room !== null && room.currentDiscussionId !== null && discussions) ?
  discussionByIdSelector(room.currentDiscussionId, discussions) :
  null;
  return  {
    player: userSelector(state),
    room,
    discussion
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    createRoom: async (roomName: string, creatorId: string) => {
      return dispatch(await createRoom(roomName, creatorId));
    },
    createUser: async (name: string | null) => {
      return dispatch(await updateUser(name));
    },
    createDiscussion: async (roomId: string) => {
      return await discussionApi.createDiscussionRequest(roomId, '');
    },
    createNewVote: async (roomId: string, playerId: string, discussionId: string) => {
      return dispatch(await createVote(roomId, playerId, discussionId));
    }
  };
};

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(CreatePageView);
