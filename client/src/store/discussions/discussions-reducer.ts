import {IDiscussion} from '../types';
import {IRemoveDiscussionAction, IAddDiscussionAction, IAddVoteAction, IUpdateDiscussions} from './discussions-action-creators';
import {ActionType} from '../reducer';

export function reducer(
    state: Array<IDiscussion> | null = [],
    action: IRemoveDiscussionAction | IAddDiscussionAction | IAddVoteAction | IUpdateDiscussions):
  Array<IDiscussion> | null {
  switch (action.type) {
    case ActionType.REMOVE_DISCUSSION: {
      const removeAction = action as IRemoveDiscussionAction;
      return state && state.filter((s) => s.id !== removeAction.id);
    }
    case ActionType.ADD_DISCUSSION: {
      const discussionAction = action as IAddDiscussionAction;
      return state && [
        ...state,
        discussionAction.discussion,
      ];
    }
    case ActionType.UPDATE_DISCUSSIONS: {
      const discussionsAction = action as IUpdateDiscussions;
      return discussionsAction.discussions;
    }
    case ActionType.ADD_VOTE: {
      const addVoteAction = action as IAddVoteAction;
      return state && state.map((discussion) => {
        if (addVoteAction.id === discussion.id) {
          discussion.voteArray[addVoteAction.playerId] = addVoteAction.vote;
        }
        return discussion;
      });
    }
    case 'CHANGE_NAME': {
      return state && state.map((s) => {
        if (s.id === 'sdafsag') {
          return {
            ...s,
            name: 'asdgsadg',
          };
        }
        return s;
      });
    }
    default: {
      return state;
    }
  }
}
