import {IDiscussion, IPlayer, IRootState} from '../../store/types';
import {compose} from 'redux';
import * as React from 'react';
import * as discussionApi from '../../api/discussion-api';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import MainPageView from './main-page-view';
import {roomSelector} from '../../store/room/room-selectors';
import {userSelector} from '../../store/user/user-selectors';
import {loadingRoom} from '../../store/room/room-operations';
import {updateUser} from '../../store/user/user-operations';
import {discussionByIdSelector, voteArraySelector, voteByPlayerSelector} from '../../store/discussions/discussions-selectors';
import {updateVote as updateValueVote, createVote} from '../../store/discussions/discussions-operations';
import {Dispatch} from 'redux';
import {discussionsSelector} from '../../store/discussions/discussions-selectors';
import { changeChoosedDiscussion } from '../../store/room/room-action-creators';

const mapStateToProps = (state: IRootState) => {
  const room = roomSelector(state);
  const player = userSelector(state);
  const discussions = discussionsSelector(state);

  const currentDiscussion = (room !== null && room.currentDiscussionId !== null && discussions !== null) ?
                            discussionByIdSelector(room.currentDiscussionId, discussions) :
                            null;

  const vote = (player !== null && currentDiscussion !== null) ? 
                voteByPlayerSelector(currentDiscussion, player) : 
                null;
  const voteArray = currentDiscussion && voteArraySelector(currentDiscussion);
  const getVote = (discussionId: string, discussions: Array<IDiscussion>, user: IPlayer) => {
    const discussion = discussionByIdSelector(discussionId, discussions);
    return discussion && voteByPlayerSelector(discussion, user);
  };
  const discussionEndAt = currentDiscussion !== null ? currentDiscussion.endAt : null;
  return {
    room,
    vote,
    player,
    discussions,
    voteArray,
    getVote,
    discussionEndAt
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    loadingRoom: async (roomHash: string, choosedDiscussionId: string | null) => {
      return dispatch(await loadingRoom(roomHash, choosedDiscussionId));
    },
    createUser: async (name: string | null) => {
      return dispatch(await updateUser(name));
    },
    updateVote: async (voteId: string, cardId: string) => {
      return dispatch(await updateValueVote(voteId, cardId));
    },
    createVote: async (roomHash: string, playerId: string, discussionId: string) => {
      return dispatch(await createVote(roomHash, playerId, discussionId));
    },
    createDiscussion: async (roomHash: string) => {
      return await discussionApi.createDiscussionRequest(roomHash, '');
    },
    changeChoosedDiscussion: (discussionId: string) => {
      return dispatch(changeChoosedDiscussion(discussionId));
    }
  };
};

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(MainPageView);
