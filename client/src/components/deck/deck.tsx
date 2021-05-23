import * as React from 'react';
import Card from '../card/card';
import {IRoom, IVote} from '../../store/types';
import './deck.css';

interface IProps {
  room: IRoom;
  vote: IVote;
  updateVote(voteId: string, cardId: string): void;
}

const Deck: React.FunctionComponent<IProps> = (props) => {
  return <div className="deck">
    {props.room.cards.map((card) => {
      return (
        <Card
          key={card.id}
          card={card}
          vote={props.vote}
          updateVote={props.updateVote}
        />
      );
    })}
  </div>;
};

export default Deck;
