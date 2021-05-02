import {IRootState} from '../../store/types';
import {userSelector} from '../../store/user/user-selectors';
import {connect} from 'react-redux';
import HeaderView from './header-view';

const mapStateToProps = (state: IRootState) => {
  return {
    user: userSelector(state),
  };
};

export default connect(mapStateToProps)(HeaderView);
