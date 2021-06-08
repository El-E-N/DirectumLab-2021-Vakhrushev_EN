import * as roomApi from '../../api/room-api';
import {IRoom} from '../types';
import {IRoomAction, updateRoom} from './room-action-creators';
import {Dispatch} from 'redux';
import {translateDtoCardsIntoCard} from '../card';
import {translateDtoDiscussionIntoDiscussion} from '../discussions/discussions-operations';
import {updateDiscussions} from '../discussions/discussions-action-creators';
import {IRoomDto} from '../../api/api-utils';
import {updateUser} from '../user/user-action-creators';
import authService from '../../services/auth-service';

const getStoreDates = (roomDto: IRoomDto, choosedDiscussionId: string | null) => {
  const cards = translateDtoCardsIntoCard(roomDto.cards);
  const discussions = roomDto.discussions.map((discussion) => translateDtoDiscussionIntoDiscussion(discussion, roomDto.roomPlayers));
  const id = discussions[discussions.length - 1].id;
  const choosedDId = choosedDiscussionId !== null ? choosedDiscussionId : null;
  
  const room: IRoom = {
    id: roomDto.id,
    hash: roomDto.hash,
    name: roomDto.name,
    hostId: roomDto.hostId,
    creatorId: roomDto.creatorId,
    cards,
    currentDiscussionId: id,
    choosedDiscussionId: choosedDId,
    players: roomDto.currentPlayers
  };

  return {discussions, room};
}

export const createRoom = (
  roomName: string, 
  creatorId: string
): (dispatch: Dispatch) => Promise<IRoomAction> => {
  return async (dispatch: Dispatch) => {
    const roomDto = await roomApi.createRoomRequest(roomName, creatorId);
    authService.set(roomDto.token);
    const cards = translateDtoCardsIntoCard(roomDto.cards);

    const room: IRoom = {
      id: roomDto.id,
      hash: roomDto.hash,
      name: roomDto.name,
      hostId: roomDto.hostId,
      creatorId: roomDto.creatorId,
      cards,
      currentDiscussionId: null,
      choosedDiscussionId: null,
      players: roomDto.currentPlayers
    };

    return dispatch(updateRoom(room));
  };
};

export const loadingRoom = (
  roomHash: string, 
  choosedDiscussionId: string | null
): (dispatch: Dispatch) => Promise<IRoomAction> => {
  return async (dispatch: Dispatch) => {
    const roomDto = await roomApi.loadingRoomRequest(roomHash);
    if (roomDto) authService.set(roomDto.token);
    
    if (roomDto !== null) {
      const storeDates = getStoreDates(roomDto, choosedDiscussionId);
      dispatch(updateDiscussions(storeDates.discussions));

      return dispatch(updateRoom(storeDates.room));
    } else {
      dispatch(updateDiscussions([]));

      return dispatch(updateRoom(null));
    }
  };
};

export const removePlayerFromRoom = (
  room: IRoom, 
  playerId: string
): (dispatch: Dispatch) => Promise<IRoomAction> => {
  return async (dispatch: Dispatch) => {
    dispatch(updateUser(null));

    if (room.hostId === playerId && room.players.length === 1) {
      await roomApi.deleteRoomRequest(room.hash);
      dispatch(updateDiscussions([]));

      return dispatch(updateRoom(null));

    } else {

      if (room.hostId === playerId) 
        await roomApi.changeHostRequest(room.hash, room.players[1].id);

      const roomDto = await roomApi.removePlayerFromRoomRequest(room.hash, playerId);
      authService.set(roomDto.token);
      const storeDates = getStoreDates(roomDto, room.choosedDiscussionId);

      dispatch(updateDiscussions(storeDates.discussions));

      return dispatch(updateRoom(storeDates.room));
    }
  };
};
