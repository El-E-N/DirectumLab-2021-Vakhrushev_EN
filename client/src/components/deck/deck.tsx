import * as React from 'react';
import Card, {ICard} from '../card/card';
import './deck.css';

interface ICards {
  values: Array<ICard>;
}

interface IState {
  selectedItem: string | number | null;
}

class Deck extends React.Component<ICards, IState> {
  constructor(props: ICards) {
    super(props);
    this.state = {
      selectedItem: null,
    };
    this.handleCardChange = this.handleCardChange.bind(this);
  }

  public handleCardChange(value: string | number) {
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
            onChange={() => this.handleCardChange(v.value)}
            isChecked={v.value === this.state.selectedItem}
          />
        );
      })}
    </div>;
  }
}

export default Deck;
