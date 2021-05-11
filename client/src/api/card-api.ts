import {ICardDto} from './types';
import {baseUrl, options} from './api';

export const getCardsRequest = async (): Promise<Array<ICardDto>> => {
  const response = await fetch(
      `${baseUrl}/card/getCards`,
      options.GET
  );
  return response.json();
};
