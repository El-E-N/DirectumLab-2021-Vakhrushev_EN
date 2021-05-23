import {IDiscussion, IPlayer, IRootState} from '../../store/types';
import {compose} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import MainPageView from './main-page-view';
import {roomSelector} from '../../store/room/room-selectors';
import {userSelector} from '../../store/user/user-selectors';
import {getRoom} from '../../store/room/room-operations';
import {updateUser} from '../../store/user/user-operations';
import {discussionByIdSelector, voteArraySelector, voteByPlayerSelector} from '../../store/discussions/discussions-selectors';
import {updateVote as updateValueVote, createVote as createNewVote} from '../../store/discussions/discussions-operations';
import {Dispatch} from 'redux';
import {loadingDiscussions} from '../../store/discussions/discussions-operations';
import {discussionsSelector} from '../../store/discussions/discussions-selectors';

const mapStateToProps = (state: IRootState) => {
  const room = roomSelector(state);
  const player = userSelector(state);
  const discussions = discussionsSelector(state);

  const currentDiscussion = room && room.currentDiscussionId && discussions &&
  discussionByIdSelector(room.currentDiscussionId, discussions);

  const vote = player && currentDiscussion && voteByPlayerSelector(currentDiscussion, player);
  const voteArray = currentDiscussion && voteArraySelector(currentDiscussion);

  return {
    room,
    vote,
    player,
    discussions,
    voteArray
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    getRoom: async (roomHash: string) => {
      return dispatch(await getRoom(roomHash));
    },
    createUser: async (name: string | null) => {
      return dispatch(await updateUser(name));
    },
    updateVote: async (voteId: string, cardId: string) => {
      return dispatch(await updateValueVote(voteId, cardId));
    },
    loadingDiscussions: async (roomId: string) => {
      return dispatch(await loadingDiscussions(roomId));
    },
    createVote: async (roomId: string, playerId: string, discussionId: string) => {
      return dispatch(await createNewVote(roomId, playerId, discussionId));
    },
    getVote: (discussion: IDiscussion, user: IPlayer) => voteByPlayerSelector(discussion, user),
  };
};

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(MainPageView);
