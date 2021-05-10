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

export interface IAddDiscussionAction extends Action {
  discussion: IDiscussion;
}

export const addDiscussion = (discussion: IDiscussion): IAddDiscussionAction => {
  return {
    type: ActionType.ADD_DISCUSSION,
    discussion,
  };
};

export interface IAddVoteAction extends Action {
  id: string;
  playerId: string;
  vote: IVote | null;
}

export const addVote = (id: string, playerId: string, vote: IVote): IAddVoteAction => {
  return {
    type: ActionType.ADD_VOTE,
    id,
    playerId,
    vote,
  };
};
