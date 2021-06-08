import {ICardDto, ICardDtoWithoutToken} from '../api/api-utils';
import {ICard} from './types';

export const translateDtoCardsIntoCard = (cardsDto: Array<ICardDtoWithoutToken>) => {
  return cardsDto.map((card) => {
    return translateDtoCardIntoCard(card);
  });
};

export const translateDtoCardIntoCard = (card: ICardDtoWithoutToken) => {
  let tempCard: ICard;

  if (card.name === 'question') {
    tempCard = {
      id: card.id,
      value: '?',
    };
  } else if (card.name === 'infinity') {
    tempCard = {
      id: card.id,
      value: '∞',
    };
  } else if (card.name === 'coffee') {
    tempCard = {
      id: card.id,
      value: 'coffee',
    };
  } else {
    tempCard = {
      id: card.id,
      value: card.value!,
    };
  }

  return tempCard;
};
