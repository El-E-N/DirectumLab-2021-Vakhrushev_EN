import { IRootState } from "../../store/types";
import { userSelector } from "../../store/user/user-selectors";
import HeaderView from "./header-view";
import {connect} from 'react-redux';

const mapStateToProps = (state: IRootState) => {
  return {
    user: userSelector(state)
  };
}

export default connect(mapStateToProps)(HeaderView);