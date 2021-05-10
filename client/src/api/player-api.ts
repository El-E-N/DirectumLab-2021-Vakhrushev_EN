import {IPlayerDto} from './types';
import {baseUrl, options} from './api';

export const createPlayerRequest = async (
    name: string,
): Promise<IPlayerDto> => {
  const response = await fetch(
      `${baseUrl}/player/create?name=${name}`,
      options.GET
  );
  return response.json();
};

export const getTokenRequest = async (
    id: string,
): Promise<string> => {
  const response = await fetch(
      `${baseUrl}/player/GetToken?id=${id}`,
      options.GET
  );
  return response.json();
};

export const changeNameRequest = async (
    id: string,
    name: string
): Promise<IPlayerDto> => {
  const response = await fetch(
      `${baseUrl}/player/ChangeName?playerId=${id}&name=${name}`,
      options.GET
  );
  return response.json();
};
