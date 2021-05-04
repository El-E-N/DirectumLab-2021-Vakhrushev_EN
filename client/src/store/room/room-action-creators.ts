import {Action} from 'redux';
import {ActionType} from '../reducer';
import {IRoom, IUser} from '../types';

export interface IVoteAction extends Action {
  roomId: string;
  value: string;
}

export const vote = (roomId: string, value: string): IVoteAction => {
  return {
    type: ActionType.VOTE,
    roomId,
    value,
  };
};

export interface IRoomAction extends Action {
  id: string;
  name: string;
  cards: Array<string>;
  selectedCard: string | null;
  owner: IUser;
  storiesId: Array<string>;
}

export const room = (roomId: string, name: string, cards: Array<string>, selectedCard: string | null, owner: IUser, storyId: string): IRoomAction => {
  return {
    type: ActionType.CREATE_ROOM,
    id: roomId,
    name,
    cards,
    selectedCard,
    owner,
    storiesId: [storyId],
  };
};

export interface IAddUserAction extends Action {
  user: IUser;
  roomId: string;
}

export const addUser = (ourRoom: IRoom, user: IUser): IAddUserAction => {
  return {
    type: ActionType.ADD_USER_INTO_ROOM,
    roomId: ourRoom.id,
    user
  };
};
