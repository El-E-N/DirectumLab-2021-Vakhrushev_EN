import * as roomApi from '../../api/room-api';
import * as cardApi from '../../api/card-api';
import {IRoom} from '../types';
import {createRoom as createNewRoom} from './room-action-creators';
import {Dispatch} from 'redux';
import {translateDtoCardsIntoCard} from '../card';

export const createRoom = (roomName: string, creatorId: string): any => {
  return async (dispatch: Dispatch) => {
    const roomDto = await roomApi.createRoomRequest(roomName, creatorId);
    const cardsDto = await cardApi.getCardsRequest();
    const cards = translateDtoCardsIntoCard(cardsDto);
    const room: IRoom = {
      ...roomDto,
      cards,
      currentDiscussionId: null,
      choosedDiscussionId: null,
      shownModal: false,
    };
    dispatch(createNewRoom(room));
  };
};

export const getRoom = (roomHash: string): any => {
  return async (dispatch: Dispatch) => {
    const roomDto = await roomApi.getRoomRequest(roomHash);
    const cardsDto = await cardApi.getCardsRequest();
    const cards = translateDtoCardsIntoCard(cardsDto);
    const room: IRoom = {
      ...roomDto,
      cards,
      currentDiscussionId: null,
      choosedDiscussionId: null,
      shownModal: false,
    };
    dispatch(createNewRoom(room));
  };
};
