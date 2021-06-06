import {IDiscussion, IRoom, IRootState} from '../../store/types';
import {userSelector} from '../../store/user/user-selectors';
import {roomSelector} from '../../store/room/room-selectors';
import {connect} from 'react-redux';
import HeaderView from './header-view';
import {compose} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {Dispatch} from 'redux';
import { removePlayerFromRoom } from '../../store/room/room-operations';
import { updateRoom } from '../../store/room/room-action-creators';
import { updateDiscussions } from '../../store/discussions/discussions-action-creators';
import { discussionByIdSelector, discussionsSelector } from '../../store/discussions/discussions-selectors';
import { deleteVoteRequest } from '../../api/vote-api';

const mapStateToProps = (state: IRootState) => {
  const room = roomSelector(state);
  const discussions = discussionsSelector(state);

  const currentDiscussion = (room !== null && room.currentDiscussionId !== null && discussions !== null) ?
                            discussionByIdSelector(room.currentDiscussionId, discussions) :
                            null;
  return {
    user: userSelector(state),
    room,
    currentDiscussion
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    onIndex: async (room: IRoom, playerId: string | null, discussion: IDiscussion) => {
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
             dispatch(await removePlayerFromRoom(room, playerId)) :
             null;
    }
  };
};

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(HeaderView);
