import * as roomApi from '../../api/room-api';
import * as cardApi from '../../api/card-api';
import {IRoom} from '../types';
import {createRoom as createNewRoom} from './room-action-creators';
import {Dispatch} from 'redux';
import {translateDtoCardsIntoCard} from '../card';

export const createRoom = (roomName: string, creatorId: string): any => {
  return async (dispatch: Dispatch): Promise<IRoom> => {
    const roomDto = await roomApi.createRoomRequest(roomName, creatorId);
    const cardsDto = await cardApi.getCardsRequest();
    const cards = translateDtoCardsIntoCard(cardsDto);
    const room: IRoom = {
      ...roomDto,
      cards,
    };
    dispatch(createNewRoom(room));
    return room;
  };
};

export const getRoom = (roomHash: string): any => {
  return async (dispatch: Dispatch): Promise<IRoom> => {
    const roomDto = await roomApi.getRoomRequest(roomHash);
    const cardsDto = await cardApi.getCardsRequest();
    const cards = translateDtoCardsIntoCard(cardsDto);
    const room: IRoom = {
      ...roomDto,
      cards,
    };
    dispatch(createNewRoom(room));
    return room;
  };
};
