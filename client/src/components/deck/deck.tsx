import * as React from 'react';
import Card, {ICard} from '../card/card';
import './deck.css';

interface ICards {
  values: Array<ICard>;
  // eslint-disable-next-line no-unused-vars
  onSetSelectedCard(value: string | null): void;
}

interface IState {
  selectedItem: string | null;
}

class Deck extends React.Component<ICards, IState> {
  constructor(props: ICards) {
    super(props);
    this.state = {
      selectedItem: null,
    };
    this.handleCardChange = this.handleCardChange.bind(this);
  }

  public handleCardChange(value: string | null) {
    this.props.onSetSelectedCard(value);
    this.setState({
      selectedItem: value,
    });
  }

  public render() {
    return <div className="deck">
      {this.props.values.map((v) => {
        return (
          <Card
            key={v.value}
            value={v.value}
            isSvg={v.isSvg}
            onClick={this.handleCardChange}
            isChecked={v.value === this.state.selectedItem}
          />
        );
      })}
    </div>;
  }
}

export default Deck;
