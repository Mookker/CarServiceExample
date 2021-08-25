import { gql } from "apollo-angular"

export const getCarsQuery = gql`{
  cars {
    id
    make
    model
    year
    vin
    repairOrders{
      id
      price
    }
  }
}`;

export const getRepairOrdersQuery = gql`{
  repairOrders {
    id
    price
    orderDate
    car {
      id
      model
      make
      year
      vin
      millage
    }
  }
}`;

export const createRepairOrderMutation = gql`
  mutation createRepairOrder($repairOrder: CreateRepairOrderType!) {
    createRepairOrder(repairOrder: $repairOrder) {
      id
      price
      orderDate
    }
  }
`;

export const createCarMutation = gql`
  mutation createCar($car: CreateCarType!) {
    createCar(car: $car) {
      id
    }
  }
`;

export const createCarOwnerMutation = gql`
  mutation createOwner($carOwner: CreateCarOwnerType!) {
    createOwner(carOwner: $carOwner) {
      id
    }
  }
`;

export const deleteRepairOrderMutation = gql`
  mutation deleteRepairOrder($id: Guid!) {
    deleteRepairOrder(id: $id)
}`;

export const getCarOwnersQuery = gql`{
  carOwners {
    id
    firstName
    lastName
    doB
  }
}`;
