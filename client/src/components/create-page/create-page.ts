import {compose} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import CreatePageView from './create-page-view';
import {createRoom, removePlayerFromRoom} from '../../store/room/room-operations';
import {updateUser} from '../../store/user/user-operations';
import * as discussionApi from '../../api/discussion-api';
import {Dispatch} from 'redux';
import {IDiscussion, IRoom, IRootState} from '../../store/types';
import {userSelector} from '../../store/user/user-selectors';
import {roomSelector} from '../../store/room/room-selectors';
import {discussionByIdSelector, discussionsSelector} from '../../store/discussions/discussions-selectors';
import { updateRoom } from '../../store/room/room-action-creators';
import { updateDiscussions } from '../../store/discussions/discussions-action-creators';
import { deleteVoteRequest } from '../../api/vote-api';

const mapStateToProps = (state: IRootState) => {
  const player = userSelector(state);
  const room = roomSelector(state);
  const discussions = discussionsSelector(state);
  const discussion = (room !== null && room.currentDiscussionId !== null && discussions) ?
    discussionByIdSelector(room.currentDiscussionId, discussions) :
    null;

  return  {
    player,
    room,
    discussion
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    createRoom: async (roomName: string, creatorId: string) => {
      return dispatch(await createRoom(roomName, creatorId)(dispatch));
    },

    createUser: async (name: string | null) => {
      return dispatch(await updateUser(name)(dispatch));
    },

    createDiscussion: async (roomHash: string) => {
      return await discussionApi.createDiscussionRequest(roomHash, '');
    },

    clearDates: async (room: IRoom, playerId: string | null, discussion: IDiscussion) => {
      dispatch(updateRoom(null));
      dispatch(updateDiscussions([]));

      if (playerId !== null && discussion.endAt === null) {
        const vote = discussion.voteArray[playerId];

        if (vote !== null && vote !== undefined) {
          const voteId = vote.id;
          await deleteVoteRequest(voteId);
        }
      }

      return playerId !== null ?
        dispatch(await removePlayerFromRoom(room, playerId)(dispatch)) :
        null;
    }
  };
};

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(CreatePageView);
