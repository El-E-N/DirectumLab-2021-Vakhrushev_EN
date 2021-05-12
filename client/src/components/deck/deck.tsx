import * as React from 'react';
import Card from '../card/card';
import {ICard, IRoom, IVote} from '../../store/types';
import './deck.css';

interface IProps {
  room: IRoom | null;
  vote: IVote | null;
  // eslint-disable-next-line no-unused-vars
  updateVote(voteId: string, cardId: string): void;
  // eslint-disable-next-line no-unused-vars
  updateCard(room: IRoom, selectedCard: ICard): void;
}

const Deck: React.FunctionComponent<IProps> = (props) => {
  return <div className="deck">
    {props.room && props.room.cards.map((card) => {
      return (
        <Card
          key={card.id}
          card={card}
          room={props.room}
          vote={props.vote}
          updateCard={props.updateCard}
          updateVote={props.updateVote}
        />
      );
    })}
  </div>;
};

export default Deck;
