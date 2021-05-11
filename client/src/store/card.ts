import {ICardDto} from '../api/types';
import {ICard} from './types';

export const translateDtoCardsIntoCard = (cardsDto: Array<ICardDto>) => {
  return cardsDto.map((card) => {
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
  });
};
