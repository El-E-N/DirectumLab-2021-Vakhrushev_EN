import {baseUrl, options, IPlayerDto} from './api-utils';

const playerUrl = `${baseUrl}/player`;

export const createPlayerRequest = async (
  name: string,
): Promise<IPlayerDto> => {
  const response = await fetch(
    `${playerUrl}/create`,
    {...options.POST,
    body: JSON.stringify(name)}
  );
  return response.json();
};

export const loadingPlayerRequest = async (
  id: string,
): Promise<IPlayerDto> => {
  const response = await fetch(
    `${playerUrl}/getById`,
    {...options.POST,
    body: JSON.stringify(id)}
  );
  return response.json();
};

export const getTokenRequest = async (
  id: string,
): Promise<string> => {
  const response = await fetch(
    `${playerUrl}/GetToken`,
    {...options.POST,
    body: JSON.stringify(id)}
  );
  return response.json();
};

export const changeNameRequest = async (
  id: string,
  name: string
): Promise<IPlayerDto> => {
  const response = await fetch(
    `${playerUrl}/ChangeName`,
    {...options.POST,
    body: JSON.stringify({
      playerId: id,
      name
    })}
  );
  return response.json();
};
