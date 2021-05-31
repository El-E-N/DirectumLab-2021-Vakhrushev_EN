import * as roomApi from '../../api/room-api';
import * as cardApi from '../../api/card-api';
import {IRoom} from '../types';
import {createRoom as createNewRoom} from './room-action-creators';
import {Dispatch} from 'redux';
import {translateDtoCardsIntoCard} from '../card';
import { translateDtoDiscussionIntoDiscussion } from '../discussions/discussions-operations';
import { updateDiscussions } from '../discussions/discussions-action-creators';

export const createRoom = (roomName: string, creatorId: string): any => {
  return async (dispatch: Dispatch) => {
    const roomDto = await roomApi.createRoomRequest(roomName, creatorId);
    const cardsDto = await cardApi.getCardsRequest();
    const cards = translateDtoCardsIntoCard(cardsDto);
    const room: IRoom = {
      id: roomDto.id,
      hash: roomDto.hash,
      name: roomDto.name,
      hostId: roomDto.hostId,
      creatorId: roomDto.creatorId,
      players: roomDto.players,
      cards,
      currentDiscussionId: null,
      choosedDiscussionId: null,
      shownModal: false,
    };
    return dispatch(createNewRoom(room));
  };
};

function sleep(ms: number) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

export const loadingRoom = (roomHash: string): any => {
  return async (dispatch: Dispatch) => {
    const roomDto = await roomApi.getRoomRequest(roomHash);
    const cards = translateDtoCardsIntoCard(roomDto.cards);
    console.log(1);
    const discussions = roomDto.discussions.map((discussion) => translateDtoDiscussionIntoDiscussion(discussion));
    const id = discussions[discussions.length - 1].id;
    const room: IRoom = {
      id: roomDto.id,
      hash: roomDto.hash,
      name: roomDto.name,
      hostId: roomDto.hostId,
      creatorId: roomDto.creatorId,
      players: roomDto.players,
      cards,
      currentDiscussionId: id,
      choosedDiscussionId: null,
      shownModal: false,
    };
    console.log(discussions);
    dispatch(updateDiscussions(discussions));
    return dispatch(createNewRoom(room));
  };
};
