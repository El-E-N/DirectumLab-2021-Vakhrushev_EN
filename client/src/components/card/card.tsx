import * as React from 'react';
import Input from '../input/input';
import './card.css';

export interface ICard {
  value: string;
  isSvg?: boolean;
  isChecked: boolean;
  onChange(): void;
}

const coffeeIcon = <svg className={'card__coffee'} width="44" height="44" viewBox="0 0 44 44" xmlns="http://www.w3.org/2000/svg">
  <path fillRule="evenodd" clipRule="evenodd" d={'M36.6667 5.5H7.33333V23.8333C7.33333 27.885 10.615 31.1667 14.6667 31.1667H25.6667C29.7183 31.1667 33 27.885 33 23.8333V18.3333H36.6667C38.7017 18.3333 40.3333 16.7017 40.3333 14.6667V9.16667C40.3333 7.13167 38.7017 5.5 36.6667 5.5ZM36.6667 14.6667H33V9.16667H36.6667V14.6667ZM36.6667 38.5H3.66667V34.8333H36.6667V38.5Z'}/>
</svg>;

const Card: React.FunctionComponent<ICard> = (props) => {
  return <label className="card">
    <Input type={'radio'} name={'cards'} value={props.value} className={'card__input'}/>
    <div className="card__content">
      {(props.isSvg || false) ? coffeeIcon : props.value}
    </div>
  </label>;
};

export default Card;
