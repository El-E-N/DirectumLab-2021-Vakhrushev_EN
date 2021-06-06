import {IDiscussion} from '../types';
import {IRemoveDiscussionAction, IAddDiscussionAction, IUpdateDiscussions, IUpdateVoteAction} from './discussions-action-creators';
import {ActionType} from '../reducer';

export function reducer(
    state: Array<IDiscussion> = [],
    action: IRemoveDiscussionAction | IAddDiscussionAction | IUpdateDiscussions | IUpdateVoteAction):
  Array<IDiscussion> {
  switch (action.type) {
    case ActionType.REMOVE_DISCUSSION: {
      const removeAction = action as IRemoveDiscussionAction;
      return state.filter((s) => s.id !== removeAction.id);
    }
    case ActionType.ADD_DISCUSSION: {
      const discussionAction = action as IAddDiscussionAction;
      return [
        ...state,
        discussionAction.discussion,
      ];
    }
    case ActionType.UPDATE_DISCUSSIONS: {
      const discussionsAction = action as IUpdateDiscussions;
      return [...discussionsAction.discussions];
    }
    case ActionType.UPDATE_VOTE: {
      const addVoteAction = action as IUpdateVoteAction;
      return state.map((discussion) => {
        if (addVoteAction.discussionId === discussion.id) {
          discussion.voteArray[addVoteAction.playerId] = addVoteAction.vote;
        }
        return discussion;
      });
    }
    default: {
      return state;
    }
  }
}
