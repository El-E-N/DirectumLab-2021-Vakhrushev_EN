import {Action} from 'redux';
import {ActionType} from '../reducer';

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
  id: string;
  name: string | null;
  average: number | null;
  votes: { [key: string]: string }; // key - userId, value - vote
}

export const story = (id: string): IStoryAction => {
  return {
    type: ActionType.ADD_STORY,
    id,
    name: null,
    average: null,
    votes: {},
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
