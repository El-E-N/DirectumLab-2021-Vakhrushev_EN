import * as roomApi from '../../api/room-api';
import {IRoom} from '../types';
import {createRoom as createNewRoom} from './room-action-creators';
import {Dispatch} from 'redux';

export const createRoom = (roomName: string, creatorId: string): any => {
  return async (dispatch: Dispatch): Promise<IRoom> => {
    const roomDto = await roomApi.createRoomRequest(roomName, creatorId);
    const room: IRoom = {
      ...roomDto,
      cards: ['0', '0.5', '1', '2', '3', '5', '8', '13', '20', '40', '100', '?', '∞', 'coffee'],
      selectedCard: null
    };
    dispatch(createNewRoom(room));
    return room;
  };
};

export const getRoom = (roomHash: string): any => {
  return async (dispatch: Dispatch): Promise<IRoom> => {
    const roomDto = await roomApi.getRoomRequest(roomHash);
    const room: IRoom = {
      ...roomDto,
      cards: ['0', '0.5', '1', '2', '3', '5', '8', '13', '20', '40', '100', '?', '∞', 'coffee'],
      selectedCard: null
    };
    dispatch(createNewRoom(room));
    return room;
  };
};
