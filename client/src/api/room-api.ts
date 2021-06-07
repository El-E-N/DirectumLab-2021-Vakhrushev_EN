import {baseUrl, options, IRoomDto} from './api-utils';

const roomUrl = `${baseUrl}/room`;

export const createRoomRequest = async (
    roomName: string,
    creatorId: string,
): Promise<IRoomDto> => {
  const response = await fetch(
      `${roomUrl}/create`,
      {...options.POST,
      body: JSON.stringify({
        name: roomName,
        creatorId
      })});
  return response.json();
};

export const getRoomRequest = async (
    hash: string,
): Promise<IRoomDto | null> => {
  const response = await fetch(
      `${roomUrl}/getByHash`,
      {...options.POST,
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
      {...options.POST,
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
      {...options.POST,
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
      {...options.POST,
      body: JSON.stringify({
        roomHash,
        playerId: hostId
      })}
  );
  return response.json();
};

export const deleteRoomRequest = async (
  roomHash: string
) => {
  await fetch(
    `${roomUrl}/Delete`,
    {...options.POST,
    body: JSON.stringify(roomHash)}
  );
}
