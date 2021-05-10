import {IDiscussion, IVote} from '../types';
import {ICreateDiscussionAction, IUpdateVoteAction} from './discussion-action-creators';
import {ActionType} from '../reducer';

export function reducer(
    state: IDiscussion | null = null,
    action: ICreateDiscussionAction | IUpdateVoteAction):
  IDiscussion | null {
  switch (action.type) {
    case ActionType.UPDATE_VOTE:
      const voteAction = action as IUpdateVoteAction;
      const voteArray: {[p: string]: IVote | null} = {};
      for (let playerId in state && state.voteArray) {
        // @ts-ignore
        if (state && state.voteArray[playerId] !== null && state.voteArray[playerId].id === voteAction.voteId) {
          voteArray[playerId] = {id: voteAction.voteId, card: voteAction.card};
        } else {
          voteArray[playerId] = state && state.voteArray[playerId];
        }
      }
      return state && {
        ...state,
        voteArray,
      };
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
