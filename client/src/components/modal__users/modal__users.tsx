import * as React from 'react';
import { IVote, IPlayer } from '../../store/types';
import ModalUser, {IUser} from '../modal__user/modal__user';
import './modal__users.css';

interface IProps {
  players: Array<IPlayer>;
  voteArray: { [key: string]: IVote | null };
}

const ModalUsers: React.FunctionComponent<IProps> = (props) => {
  const getModalPlayers = () => {
    const modalPlayers: {name: string, value: string}[] = [];
    for (let i = 0; i < props.players.length; i++) {
      const player = props.players[i];
      const name = player.name;
      const vote = props.voteArray[player.id];
      const card = vote && vote.card;
      const value = card && card.value;
      value && modalPlayers.push({name, value});
    }
    return modalPlayers;
  };

  return <ul className="modal__users">
    {getModalPlayers().map((modalPlayer) => {
      return <ModalUser
        key={modalPlayer.name + modalPlayer.value}
        name={modalPlayer.name}
        value={modalPlayer.value}
      />;
    })}
  </ul>;
};

export default ModalUsers;
