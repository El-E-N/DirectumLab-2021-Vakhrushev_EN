import {IUser} from '../store/types';

const baseUrl = 'http://localhost:3030/api';

const options = {
  GET: {
    method: 'GET',
    headers: {'Content-Type': 'application/json'}
  }
};

export const createRoomRequest = async (
    roomName: string,
    creatorId: string,
): Promise<{id: string, hash: string, name: string, players: Array<IUser>, hostId: string, creatorId: string}> => {
  const response = await fetch(
      `${baseUrl}/room/create?name=${roomName}&creatorId=${creatorId}`,
      options.GET);
  return response.json();
};

export const getRoomRequest = async (
    hash: string,
): Promise<{id: string, roomHash: string, name: string, players: Array<IUser>, hostId: string, creatorId: string}> => {
  const response = await fetch(
      `${baseUrl}/room/getbyhash?name=${hash}&hash=${hash}`,
      options.GET
  );
  return response.json();
};

export const addUserIntoRoom = async (
    roomId: string,
    playerId: string,
): Promise<{id: string, hash: string, name: string, players: Array<IUser>, hostId: string, creatorId: string}> => {
  const response = await fetch(
      `${baseUrl}/room/addplayer?roomId=${roomId}&playerId=${playerId}`,
      options.GET
  );
  return response.json();
};

export const createUserRequest = async (
    name: string,
): Promise<{id: string, name: string}> => {
  const response = await fetch(`${baseUrl}/player/create?name=${name}`,
      options.GET
  );
  return response.json();
};
