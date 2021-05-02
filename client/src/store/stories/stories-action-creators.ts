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
