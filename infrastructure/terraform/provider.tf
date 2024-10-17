locals {
  region = "af-south-1"
  name   = "adeyemi-cluster"
  vpc_cidr = "10.0.0.0/16"
  azs      = ["af-south-1a", "af-south-1b"]  #  AP-south region
  public_subnets  = ["10.0.1.0/24", "10.0.2.0/24"]
  private_subnets = ["10.0.3.0/24", "10.0.4.0/24"]
  intra_subnets   = ["10.0.5.0/24", "10.0.6.0/24"]
  tags = {
    #Example = test.name
    Environment = "dev"
  }
}

provider "aws" {
  region = local.region
}