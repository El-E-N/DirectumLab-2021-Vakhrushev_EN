import {Action} from 'redux';
import {ActionType} from '../reducer';
import {IRoom} from '../types';

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
  ownerId: string;
  usersId: Array<string>;
}

export const room = (roomId: string, name: string, cards: Array<string>, selectedCard: string | null, ownerId: string): IRoomAction => {
  return {
    type: ActionType.CREATE_ROOM,
    id: roomId,
    name,
    cards,
    selectedCard,
    ownerId,
    usersId: [ownerId],
  };
};

export interface IAddUserAction extends Action {
  userId: string;
  roomId: string;
}

export const addUser = (ourRoom: IRoom, userId: string): IRoomAction => {
  return {
    type: ActionType.ADD_USER_INTO_ROOM,
    id: ourRoom.id,
    name: ourRoom.name,
    cards: ourRoom.cards,
    selectedCard: ourRoom.selectedCard,
    ownerId: ourRoom.ownerId,
    usersId: [...ourRoom.usersId, userId],
  };
};
