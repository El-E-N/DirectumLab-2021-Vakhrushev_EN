import {baseUrl, post, IPlayerDto} from './api-utils';

const playerUrl = `${baseUrl}/player`;

export const createPlayerRequest = async (
  name: string,
): Promise<IPlayerDto> => {
  const response = await fetch(
    `${playerUrl}/create`,
    {...post(),
    body: JSON.stringify(name)}
  );
  return response.json();
};

export const loadingPlayerRequest = async (
  id: string,
): Promise<IPlayerDto> => {
  const response = await fetch(
    `${playerUrl}/getById`,
    {...post(),
    body: JSON.stringify(id)}
  );
  return response.json();
};

export const loadingPlayerByTokenRequest = async (): Promise<IPlayerDto> => {
  const response = await fetch(
    `${playerUrl}/getByToken`,
    post()
  );
  return response.json();
};

export const getTokenRequest = async (
  id: string,
): Promise<string> => {
  const response = await fetch(
    `${playerUrl}/GetToken`,
    {...post(),
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
    {...post(),
    body: JSON.stringify({
      playerId: id,
      name
    })}
  );
  return response.json();
};
