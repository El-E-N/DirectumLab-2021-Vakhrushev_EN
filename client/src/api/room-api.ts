import {baseUrl, post, IRoomDto} from './api-utils';

const roomUrl = `${baseUrl}/room`;

export const createRoomRequest = async (
  roomName: string,
  creatorId: string,
): Promise<IRoomDto> => {
  const response = await fetch(
    `${roomUrl}/create`,
    {...post(),
    body: JSON.stringify({
      name: roomName,
      creatorId
    })}
  );
  return response.json();
};

export const loadingRoomRequest = async (
  hash: string,
): Promise<IRoomDto | null> => {
  const response = await fetch(
    `${roomUrl}/getByHash`,
    {...post(),
    body: JSON.stringify(hash)}
  );
  return response.status !== 204 ?
    response.json() :
    null;
};

export const addPlayerIntoRoomRequest = async (
  roomHash: string,
  playerId: string,
): Promise<IRoomDto> => {
  const response = await fetch(
    `${roomUrl}/addPlayer`,
    {...post(),
    body: JSON.stringify({
      roomHash,
      playerId
    })}
  );
  return response.json();
};

export const removePlayerFromRoomRequest = async (
  roomHash: string,
  playerId: string,
): Promise<IRoomDto> => {
  const response = await fetch(
    `${roomUrl}/removePlayer`,
    {...post(),
    body: JSON.stringify({
      roomHash,
      playerId
    })}
  );
  return response.json();
};

export const changeHostRequest = async (
  roomHash: string,
  hostId: string,
): Promise<IRoomDto> => {
  const response = await fetch(
    `${roomUrl}/ChangeHost`,
    {...post(),
    body: JSON.stringify({
      roomHash,
      playerId: hostId
    })}
  );
  return response.json();
};

export const deleteRoomRequest = async (
  roomHash: string
): Promise<string> => {
  const response = await fetch(
    `${roomUrl}/Delete`,
    {...post(),
    body: JSON.stringify(roomHash)}
  );
  return response.json();
}
