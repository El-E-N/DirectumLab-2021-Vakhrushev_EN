import {baseUrl, options, ICardDto} from './api-utils';

export const getCardsRequest = async (): Promise<Array<ICardDto>> => {
  const response = await fetch(
    `${baseUrl}/card/getCards`,
    options.GET
  );
  return response.json();
};
