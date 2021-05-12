import {IDiscussion} from '../types';
import {ICreateDiscussionAction, IUpdateVoteAction} from './discussion-action-creators';
import {ActionType} from '../reducer';

export function reducer(
    state: IDiscussion | null = null,
    action: ICreateDiscussionAction | IUpdateVoteAction):
  IDiscussion | null {
  switch (action.type) {
    case ActionType.UPDATE_VOTE:
      const voteAction = action as IUpdateVoteAction;
      if (state) {
        const voteArray = {
          ...state.voteArray,
          [voteAction.voteId]: {id: voteAction.voteId, card: voteAction.card},
        };
        return {
          ...state,
          voteArray,
        };
      }
      return null;
    case ActionType.CREATE_DISCUSSION:
      const createAction = action as ICreateDiscussionAction;
      return createAction.discussion;
    case 'CHANGE_NAME':
      return state && {
        ...state,
        name: 'kjdbfsn',
      };
    default:
      return state;
  }
}
