import {baseUrl, options, IRoomDto} from './api-utils';

const roomUrl = `${baseUrl}/room`;

export const createRoomRequest = async (
    roomName: string,
    creatorId: string,
): Promise<IRoomDto> => {
  const response = await fetch(
      `${roomUrl}/create?name=${roomName}&creatorId=${creatorId}`,
      options.GET);
  return response.json();
};

export const getRoomRequest = async (
    hash: string,
): Promise<IRoomDto | null> => {
  const response = await fetch(
      `${roomUrl}/getByHash?hash=${hash}`,
      options.GET
  );
  return response.status !== 204 ?
    response.json() :
    null;
};

export const addPlayerIntoRoomRequest = async (
    roomId: string,
    playerId: string,
): Promise<IRoomDto> => {
  const response = await fetch(
      `${roomUrl}/addPlayer?roomId=${roomId}&playerId=${playerId}`,
      options.GET
  );
  return response.json();
};

export const removePlayerFromRoomRequest = async (
    roomId: string,
    playerId: string,
): Promise<IRoomDto> => {
  const response = await fetch(
      `${roomUrl}/removePlayer?roomId=${roomId}&playerId=${playerId}`,
      options.GET
  );
  return response.json();
};

export const changeHostRequest = async (
    roomId: string,
    hostId: string,
): Promise<IRoomDto> => {
  const response = await fetch(
      `${roomUrl}/ChangeHost?roomId=${roomId}&hostId=${hostId}`,
      options.GET
  );
  return response.json();
};

export const deleteRoomRequest = async (
  roomId: string
) => {
  await fetch(
    `${roomUrl}/Delete?roomId=${roomId}`,
    options.GET
  );
}
