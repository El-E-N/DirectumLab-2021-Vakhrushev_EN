import {baseUrl, get, ICardDto} from './api-utils';

export const getCardsRequest = async (): Promise<Array<ICardDto>> => {
  const response = await fetch(
    `${baseUrl}/card/getCards`,
    get()
  );
  return response.json();
};
