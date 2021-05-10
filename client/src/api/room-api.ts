import {IRoomDto} from './types';
import {baseUrl, options} from './api';

export const createRoomRequest = async (
    roomName: string,
    creatorId: string,
): Promise<IRoomDto> => {
  const response = await fetch(
      `${baseUrl}/room/create?name=${roomName}&creatorId=${creatorId}`,
      options.GET);
  return response.json();
};

export const getRoomRequest = async (
    hash: string,
): Promise<IRoomDto> => {
  const response = await fetch(
      `${baseUrl}/room/getByHash?hash=${hash}`,
      options.GET
  );
  return response.json();
};

export const addPlayerIntoRoomRequest = async (
    roomId: string,
    playerId: string,
): Promise<IRoomDto> => {
  const response = await fetch(
      `${baseUrl}/room/addPlayer?roomId=${roomId}&playerId=${playerId}`,
      options.GET
  );
  return response.json();
};

export const removePlayerIntoRoomRequest = async (
    roomId: string,
    playerId: string,
): Promise<IRoomDto> => {
  const response = await fetch(
      `${baseUrl}/room/removePlayer?roomId=${roomId}&playerId=${playerId}`,
      options.GET
  );
  return response.json();
};

export const changeHostRequest = async (
    roomId: string,
    hostId: string,
): Promise<IRoomDto> => {
  const response = await fetch(
      `${baseUrl}/room/ChangeHost?roomId=${roomId}&hostId=${hostId}`,
      options.GET
  );
  return response.json();
};
