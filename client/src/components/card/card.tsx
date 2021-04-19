import * as React from 'react';
import './card.css';

interface IProps {
  value: string;
  isSvg?: boolean;
  d?: string;
}

const Card: React.FunctionComponent<IProps> = (props) => {
  return (props.isSvg || false) ?
    <label className="card">
      <input className="card__input" type="radio" name="cards" value={props.value} />
      <div className="card__content">
        <svg className={('card__' + props.value) || ''} width="44" height="44" viewBox="0 0 44 44" xmlns="http://www.w3.org/2000/svg">
          <path fillRule="evenodd" clipRule="evenodd" d={props.d || ''}/>
        </svg>
      </div>
    </label>
    :
    <label className="card">
      <input className="card__input" type="radio" name="cards" value={props.value} />
      <div className="card__content">{props.value}</div>
    </label>;
};

export default Card;
