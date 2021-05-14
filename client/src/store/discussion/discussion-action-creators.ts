import {Action} from 'redux';
import {ActionType} from '../reducer';
import {ICard, IDiscussion} from '../types';

export interface IUpdateVoteAction extends Action {
  voteId: string;
  card: ICard | null;
  playerId: string;
}

export const updateVote = (voteId: string, card: ICard | null, playerId: string): IUpdateVoteAction => {
  return {
    type: ActionType.UPDATE_VOTE,
    voteId,
    card,
    playerId
  };
};

export interface ICreateDiscussionAction extends Action {
  discussion: IDiscussion;
}

export const createDiscussion = (discussion: IDiscussion): ICreateDiscussionAction => {
  return {
    type: ActionType.CREATE_DISCUSSION,
    discussion,
  };
};

export interface IGetVoteAction extends Action {
  playerId: string;
}

export const getVote = (playerId: string): IGetVoteAction => {
  return {
    type: ActionType.GET_VOTE,
    playerId,
  };
};
