import {baseUrl, options, IPlayerDto} from './api-utils';

const playerUrl = `${baseUrl}/player`;

export const createPlayerRequest = async (
    name: string,
): Promise<IPlayerDto> => {
  const response = await fetch(
      `${playerUrl}/create?name=${name}`,
      options.GET
  );
  return response.json();
};

export const getTokenRequest = async (
    id: string,
): Promise<string> => {
  const response = await fetch(
      `${playerUrl}/GetToken?id=${id}`,
      options.GET
  );
  return response.json();
};

export const changeNameRequest = async (
    id: string,
    name: string
): Promise<IPlayerDto> => {
  const response = await fetch(
      `${playerUrl}/ChangeName?playerId=${id}&name=${name}`,
      options.GET
  );
  return response.json();
};
