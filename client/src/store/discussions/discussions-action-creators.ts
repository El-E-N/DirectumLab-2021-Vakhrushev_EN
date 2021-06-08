import {Action} from 'redux';
import {ActionType} from '../reducer';
import {IDiscussion, IVote} from '../types';

export interface IRemoveDiscussionAction extends Action {
  id: string;
}

export const removeDiscussion = (id: string): IRemoveDiscussionAction => {
  return {
    type: ActionType.REMOVE_DISCUSSION,
    id,
  };
};

export interface IUpdateVoteAction extends Action {
  discussionId: string;
  playerId: string;
  vote: IVote | null;
}

export const updateVote = (discussionId: string, playerId: string, vote: IVote): IUpdateVoteAction => {
  return {
    type: ActionType.UPDATE_VOTE,
    discussionId,
    playerId,
    vote,
  };
};

export interface IUpdateDiscussions extends Action {
  discussions: Array<IDiscussion>;
}

export const updateDiscussions = (discussions: Array<IDiscussion>): IUpdateDiscussions => {
  return {
    type: ActionType.UPDATE_DISCUSSIONS,
    discussions
  }
};
