import {Action} from 'redux';
import {ActionType} from '../reducer';
import {IStory} from '../types';

export interface IRemoveStoryAction extends Action {
  id: string;
}

export const removeStory = (id: string): IRemoveStoryAction => {
  return {
    type: ActionType.REMOVE_STORY,
    id,
  };
};

export interface IStoryAction extends Action {
  story: IStory;
}

export const createStory = (story: IStory): IStoryAction => {
  return {
    type: ActionType.ADD_STORY,
    story,
  };
};

export interface IAddVoteAction extends Action {
  id: string;
  userId: string;
  vote: string;
}

export const addVote = (id: string, userId: string, vote: string): IAddVoteAction => {
  return {
    type: ActionType.ADD_VOTE,
    id,
    userId,
    vote,
  };
};
